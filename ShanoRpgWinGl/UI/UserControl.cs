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
    abstract class UserControl : IEnumerable<UserControl>
    {
        public const float Anchor = 0.01f;

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

        private Vector2 ParentPosition
        {
            get { return Parent != null ? Parent.absolutePosition : Vector2.Zero; }
        }
        private Vector2 ParentSize
        {
            get { return Parent != null ? Parent.Size : Vector2.Zero; }
        }

        protected Vector2 absolutePosition;
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

        public Point ScreenPosition
        {
            get
            {
                return ScreenInfo.UiToScreen(absolutePosition);
            }
        }
        public Point ScreenSize
        {
            get
            {
                return ScreenInfo.UiToScreen(AbsolutePosition + Size) - ScreenPosition;
            }
        }


        public float Bottom
        {
            get { return RelativePosition.Y + Size.Y; }
        }

        public float Right
        {
            get { return RelativePosition.X + Size.X; }
        }

        /// <summary>
        /// Gets or sets the size of the control. 
        /// </summary>
        public Vector2 Size;


        public bool ClickThrough;

        public bool Locked = true;

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

        public virtual void Update(int msElapsed)
        {
            foreach (var c in this.Controls)
                c.Update(msElapsed);

            mouseState = Mouse.GetState();
            keyboardState = Keyboard.GetState();

            //check mouse events
            var mp = ScreenInfo.ScreenToUi(mouseState.Position);
            var omp = ScreenInfo.ScreenToUi(oldMouseState.Position);

            var nowHasPointer = this.isHover(mp);
            var oldHasPointer = this.isHover(omp);

            if (mouseState.LeftButton == ButtonState.Released)
                dragPoint = Vector2.Zero;

            if (dragPoint != Vector2.Zero)  //dragging around
            {
                var d = mp - dragPoint;
                this.RelativePosition += d;
                dragPoint += d;


                //don't trigger events now. 
            }
            else if (nowHasPointer)
            {
                if (!oldHasPointer)
                {
                    if (MouseEnter != null)
                        MouseEnter();
                }
                else
                {
                    if (mp != omp)
                        if (MouseMove != null)
                            MouseMove(mp);
                }

                if (mouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released)
                {
                    if (MouseDown != null)
                        MouseDown(mp);
                }
                else if (oldMouseState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released)
                {
                    if (MouseUp != null)
                        MouseUp(mp);
                }
            }
            else if (oldHasPointer)
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

        public bool ChildContains(Vector2 p)
        {
            return Controls.Any(c => !c.ClickThrough && c.Contains(p));
        }

        private bool isHover(Vector2 p)
        {
            return Contains(p) && !ChildContains(p);
        }

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
