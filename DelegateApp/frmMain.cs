using DelegateApp.RequestCreators;

namespace DelegateApp
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetPostRequestCreator req=new GetPostRequestCreator();
            var posts=req.GetPost();

            MessageBox.Show(posts.FirstOrDefault().title);
        }
    }
}
