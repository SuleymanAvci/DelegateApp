using DelegateApp.Models;
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
            var req = new GetPostRequestCreator();
            req.OnRequestFinished += Req_OnRequestFinished;
            req.SetRequestStartedMethod(() =>
            {
                MessageBox.Show("Request started");
            });
            var posts = req.GetPost();

            MessageBox.Show(posts.FirstOrDefault().title);
        }

        private void Req_OnRequestFinished(object sender, int e)
        {
            MessageBox.Show($"Request finished with size of {e}");
        }

        private void button2_Click(object sender, EventArgs e)
        {

            var req = new CreatePostRequestCreator();

            req.SetRequestStartedMethod(() =>
            {
                MessageBox.Show("Request started");
            });

            var posts = req.CreatePost(new PostModel()
            {
                userId = 66,
                title = "DeneTitle66",
                body = "DeneBody66"
            });

            req.CreatePost(null);
            MessageBox.Show($"{posts.id}");

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
