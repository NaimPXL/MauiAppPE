using IWantPicturesOfSpidermanMauiApp.DTO;
using IWantPicturesOfSpidermanMauiApp.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace IWantPicturesOfSpidermanMauiApp
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<PictureDTO> Pictures { get; set; } = new();
        RestService _restService;

        public MainPage()
        {
            InitializeComponent();
            _restService = new RestService();
            BindingContext = this;
        }

        private async void OnRefreshClicked(object sender, EventArgs e)
        {
            List<PictureDTO> list = new List<PictureDTO>();
            list = await _restService.GetAllPicturesAsync();
            Pictures.Clear();
            foreach (PictureDTO picture in list)
            {
                Pictures.Add(picture);
            }
        }
    }
}
