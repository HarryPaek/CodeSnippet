using log4net;
using System;
using System.Linq;
using System.Windows.Forms;
using WinFormXmlChangeReasons.Helpers;
using WinFormXmlChangeReasons.I18N;
using WinFormXmlChangeReasons.ViewModel;

namespace WinFormXmlChangeReasons
{
    public partial class MainForm : Form
    {
        private readonly ILog _logger = null;

        public MainForm()
        {
            this._logger = LogManager.GetLogger(this.GetType());
            InitializeComponent();
        }

        #region Event Handlers

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeUI();
            LocalizeUI();

            InitializeChangeReasonList();
            InitializeLocaleList();
        }

        #endregion

        #region Private Methods

        private void InitializeUI()
        {
            this.tsMenuItemKoKR.Image = this.iconImageList.Images["ko_KR"];
            this.tsMenuItemEnUS.Image = this.iconImageList.Images["en_US"];

            this.tsBtnLoginLogout.Image = this.iconImageList.Images["logIn"];
        }

        private void LocalizeUI()
        {
            this.tsBtnLoginLogout.Text = LocalizedText.TEXT_LOGIN;

            this.tsDropDownBtnLocale.Text = LocalizedText.TEXT_MENUGROUP_LOCALE;
            this.tsMenuItemKoKR.Text = LocalizedText.TEXT_MENUITEM_KOREAN;
            this.tsMenuItemEnUS.Text = LocalizedText.TEXT_MENUITEM_ENGLISH;
        }

        private void InitializeChangeReasonList()
        {

            var changeReasonList = ChangeReasonXmlHelper.FromXml(".\\Config\\ChangeReasons.xml");

            if(this._logger.IsDebugEnabled) {
                foreach (var changeReasoInfo in changeReasonList.Items.Select((item, index) => new { Index = index, Value = item}))
                {
                    this._logger.DebugFormat("changeReasonList[{0}] = [{1}]", changeReasoInfo.Index, changeReasoInfo.Value);
                }
            }

            this.cBoxChangeReasonList.SelectedIndex = -1;
            this.cBoxChangeReasonList.Items.Clear();

            this.cBoxChangeReasonList.Items.AddRange(changeReasonList.Items.Select(item => new ChangeReasonViewModel(item)).ToArray());
        }

        private void InitializeLocaleList()
        {
            var localeList = CultureInfoHelper.GetAvailableCultures(typeof(LocalizedText));
        }

        #endregion
    }
}
