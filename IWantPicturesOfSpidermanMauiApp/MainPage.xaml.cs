using IWantPicturesOfSpidermanMauiApp.DTO;
using IWantPicturesOfSpidermanMauiApp.Services;
using System.Threading.Tasks;

namespace IWantPicturesOfSpidermanMauiApp
{
    public partial class MainPage : ContentPage
    {

        public List<PictureDTO> Pictures { get; set; } = new List<PictureDTO>();
        RestService _restService;

        public MainPage()
        {
            InitializeComponent();
            _restService = new RestService();
        }


        private async void OnRefreshClicked(object sender, EventArgs e)
        {
            List<PictureDTO> list = new List<PictureDTO>();
            list = await _restService.GetAllPicturesAsync();

            Pictures = list;
        }
    }
}
