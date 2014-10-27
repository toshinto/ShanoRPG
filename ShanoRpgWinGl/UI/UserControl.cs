using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ShanoRpgWinGl.UI
{
    /// <summary>
    /// Represents a user interface control. 
    /// </summary>
    abstract class UserControl : IEnumerable<UserControl>
    {
        /// <summary>
        /// A constant specifying the default distance between elements. 
        /// </summary>
        public const float Anchor = 0.01f;

        /// <summary>
        /// All children of this control. 
        /// </summary>
        List<UserControl> Controls = new List<UserControl>();


        /// <summary>
        /// Gets or sets the position of this control in its parent's coordinate space. 
        /// </summary>
        public Vector2 RelativePosition
        {
            get
            {
                return (AbsolutePosition - ParentPosition);
            }
            set
            {
                this.AbsolutePosition = ParentPosition + value;
            }
        }

        /// <summary>
        /// Gets the absolute position of this control's parent. 
        /// </summary>
        /// <returns></returns>
        private Vector2 ParentPosition
        {
            get { return Parent != null ? Parent.absolutePosition : Vector2.Zero; }
        }
        /// <summary>
        /// Gets the size of this control's parent. 
        /// </summary>
        /// <returns></returns>
        private Vector2 ParentSize
        {
            get { return Parent != null ? Parent.Size : Vector2.Zero; }
        }

        protected Vector2 absolutePosition;
        /// <summary>
        /// Gets or sets the absolute position of this control in UI coordinates. 
        /// </summary>
        public Vector2 AbsolutePosition
        {
            get
            {
                return absolutePosition;
            }
            set
            {
                if (value != absolutePosition)
                {
                    var d = value - absolutePosition;
                    foreach (var c in this)
                        c.AbsolutePosition += d;
                    this.absolutePosition = value;
                }
            }
        }

        /// <summary>
        /// Gets the screen position of this control, in pixels. 
        /// </summary>
        public Point ScreenPosition
        {
            get
            {
                return ScreenInfo.UiToScreen(absolutePosition);
            }
        }
        /// <summary>
        /// Gets the screen size of this control, in pixels. 
        /// </summary>
        public Point ScreenSize
        {
            get
            {
                return ScreenInfo.UiToScreen(AbsolutePosition + Size) - ScreenPosition;
            }
        }

        /// <summary>
        /// Gets the bottom Y coordinate of this control relative to its parent. 
        /// </summary>
        public float Bottom
        {
            get { return RelativePosition.Y + Size.Y; }
        }

        /// <summary>
        /// Gets the right X coordinate of this control relative to its parent. 
        /// </summary>
        public float Right
        {
            get { return RelativePosition.X + Size.X; }
        }

        /// <summary>
        /// Gets or sets the size of the control. 
        /// </summary>
        public Vector2 Size;

        /// <summary>
        /// Gets or sets whether this control responds to mouse events. 
        /// </summary>
        public bool ClickThrough;

        /// <summary>
        /// Gets or sets whether this control can be moved 
        /// </summary>
        public bool Locked = true;

        public bool MouseOver { get; private set; }

        private Keys moveAroundKey = Keys.LeftAlt;

        public event Action<Vector2> MouseDown;
        public event Action<Vector2> MouseUp;
        public event Action<Vector2> MouseMove;
        public event Action MouseEnter;
        public event Action MouseLeave;
        public event Action<Keys> KeyDown;
        
        public UserControl Parent { get; private set; }
       
        public UserControl()
        {
            MouseDown += UserControl_MouseDown;
        }

        #region Drag to move

        Vector2 dragPoint = Vector2.Zero;
        void UserControl_MouseDown(Vector2 p)
        {
            if(!Locked && oldKeyboardState.IsKeyDown(Keys.LeftShift))
            {
                dragPoint = p;
            }
        }
        #endregion

        /// <summary>
        /// Adds the specified control as a child of this control. 
        /// </summary>
        /// <param name="c"></param>
        /// <param name="relativeAnchor">True to position the control according to its relative position, false to keep the absolute one. </param>
        public void Add(UserControl c, bool relativeAnchor = true)
        {
            var pos = c.RelativePosition;
            this.Controls.Add(c);
            c.Parent = this;
            if(relativeAnchor)
                c.RelativePosition = pos;
        }

        protected MouseState 
            oldMouseState = Mouse.GetState(),
            mouseState = Mouse.GetState();

        protected KeyboardState 
            oldKeyboardState = Keyboard.GetState(),
            keyboardState = Keyboard.GetState();

        /// <summary>
        /// Updates the control's state and fires the appropriate events in response to user input. 
        /// </summary>
        /// <param name="msElapsed"></param>
        public virtual void Update(int msElapsed)
        {
            foreach (var c in this.Controls)
                c.Update(msElapsed);

            mouseState = Mouse.GetState();
            keyboardState = Keyboard.GetState();

            //check mouse events
            var mp = ScreenInfo.ScreenToUi(mouseState.Position);
            var omp = ScreenInfo.ScreenToUi(oldMouseState.Position);

            MouseOver = this.isHover(mp);
            var oldMouseOver = this.isHover(omp);

            if (mouseState.LeftButton == ButtonState.Released)
                dragPoint = Vector2.Zero;

            if (dragPoint != Vector2.Zero)  //the control is being moved around by the user. 
            {
                var d = mp - dragPoint;
                this.RelativePosition += d;
                dragPoint += d;


                //don't trigger events now. 
            }
            else if (MouseOver) // check if the mouse is over the control. 
            {
                if (!oldMouseOver)  // if it wasn't over before, fire the Mouse event. 
                {
                    if (MouseEnter != null)
                    {
                        MouseEnter();
                        Console.WriteLine("MouseEnter " + this.GetType().Name);
                    }
                }
                else
                {
                    if (mp != omp)  // if the mouse was here and the cursor was moved, fire the MouseMove event
                        if (MouseMove != null)
                            MouseMove(mp);
                }

                if (mouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released)
                {
                    if (MouseDown != null)  // if we *just* pressed the mouse button, fire the MouseDown event. 
                        MouseDown(mp);
                }
                else if (oldMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released)
                {
                    if (MouseUp != null)    // if we *just* released the mouse button, fire the MouseUp event. 
                        MouseUp(mp);
                }
            }
            else if (oldMouseOver)      //MouseLeave
                if(MouseLeave != null)
                    MouseLeave();

            oldMouseState = mouseState;
            oldKeyboardState = keyboardState;
        }


        public virtual void Draw(SpriteBatch sb)
        {
            foreach (var c in this.Controls)
                c.Draw(sb);
        }

        public bool Contains(Vector2 p)
        {
            var localP = p - AbsolutePosition;
            return localP.X >= 0 && localP.Y >= 0 && localP.X < Size.X && localP.Y < Size.Y;
        }

        /// <summary>
        /// Gets whether any of this control's children contains the given point. 
        /// </summary>
        public bool ChildContains(Vector2 p)
        {
            return Controls.Any(c => !c.ClickThrough && c.Contains(p));
        }

        /// <summary>
        /// Gets whether the mouse is over the control, but not over a child control. 
        /// </summary>
        private bool isHover(Vector2 p)
        {
            return Contains(p) && !ChildContains(p);
        }

        // Implement IEnumerable<UserControl> interface for children. 

        public IEnumerator<UserControl> GetEnumerator()
        {
            return Controls.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Controls.GetEnumerator();
        }
    }
}
