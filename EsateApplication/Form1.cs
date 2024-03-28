using Business.Helpers;
using Business.ServiceContracts;
using Business.Services;
using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EsateApplication
{
    public partial class Form1 : Form
    {
        private readonly IUserService _userService;
        private readonly IEstateAgentService _estateAgentService;
        private readonly ICategoryService _categoryService;
        private readonly IRoomService _roomService;
        private readonly IEstateService _estateService;
        private readonly IPhotoService _photoService;

        public Form1(
            IUserService userService, 
            IEstateAgentService estateAgentService, 
            ICategoryService categoryService, 
            IRoomService roomService, 
            IEstateService estateService,
            IPhotoService photoService
            )
        {
            InitializeComponent();
            _estateAgentService = estateAgentService;
            _userService = userService;
            _categoryService = categoryService;
            _roomService = roomService;
            _estateService = estateService;
            _photoService = photoService;
        }

        public TabControl LoginTabControl
        {
            get { return loginTab; }
            set { loginTab = value; }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ActiveForm.Hide();
            SignUp signUpForm = new SignUp(_userService, _estateAgentService, _categoryService, _roomService,_estateService, _photoService);
            signUpForm.SignupTabControl.SelectedIndex = 0;
            signUpForm.ShowDialog();




            //signUpForm.sign
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var isUserAuthenticated = await _userService.LoginAsync(loginEmail.Text, loginPassword.Text);
            if (isUserAuthenticated != null)
            {
                loginEmail.Text = "";
                loginPassword.Text = "";
                ActiveForm.Hide();
                SessionManager.Login(isUserAuthenticated.Email, isUserAuthenticated.ID);
                UserMain usermain = new UserMain(_estateAgentService, _categoryService, _roomService, _estateService);
                usermain.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ActiveForm.Hide();
            SignUp signUpForm = new SignUp(_userService, _estateAgentService, _categoryService, _roomService, _estateService, _photoService);
            signUpForm.SignupTabControl.SelectedIndex = 1;
            signUpForm.ShowDialog();

        }

        private async void button3_Click(object sender, EventArgs e)
        {
            var isUserAuthenticated = await _estateAgentService.LoginAsync(loginAgentEmail.Text, loginAgentPassword.Text);
            if (isUserAuthenticated != null)
            {
                loginAgentEmail.Text = "";
                loginAgentPassword.Text = "";
                //MessageBox.Show("Emlakci girisi basarili");
                ActiveForm.Hide();
                SessionManager.Login(isUserAuthenticated.Email, isUserAuthenticated.ID);
                EmlakciMain emlakMain = new EmlakciMain(_estateAgentService, _categoryService, _roomService, _estateService, _photoService);
                emlakMain.Show();
            }
        }
    }
}
