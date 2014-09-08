using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Engine.Objects;

namespace ShanoRPGWin.UI
{
    public partial class IngameHeroPanel : UserControl
    {
        public Hero currentHero;

        public IngameHeroPanel()
        {
            InitializeComponent();
        }
        public void Update()
        {
            
            if (currentHero==null)
                return;
            attributesPanel1.lblAgiNum.Text = currentHero.CurrentAgility.ToString();
            attributesPanel1.lblStrNum.Text = currentHero.CurrentStrength.ToString();
            attributesPanel1.lblIntNum.Text = currentHero.CurrentVitality.ToString();
            attributesPanel1.lblVitNum.Text = currentHero.CurrentIntellect.ToString();
            LifeManaPanel.lblLifeNum.Text = currentHero.CurrentLife.ToString() + " / " + currentHero.CurrentMaxLife.ToString();
            LifeManaPanel.lblManaNum.Text = currentHero.CurrentMana.ToString() + " / " + currentHero.CurrentMaxMana.ToString();
            dmgdefpanel.lblDefNum.Text = currentHero.CurrentDefense.ToString();
            dmgdefpanel.lblMoveSpeedNum.Text = currentHero.CurrentMoveSpeed.ToString();
            dmgdefpanel.lblDmgNun.Text = currentHero.CurrentMinDamage.ToString() + "-" + currentHero.CurrentMaxDamage.ToString();
            expPanel1.ExpBar.Value = currentHero.Experience; 
   
        }
    }

}
