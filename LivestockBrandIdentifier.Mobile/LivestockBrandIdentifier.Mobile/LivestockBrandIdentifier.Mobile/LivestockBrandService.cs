using LivestockBrandIdentifier.Mobile.Models;
using LivestockBrandIdentifier.Services;
using System.Collections.ObjectModel;

namespace LivestockBrandIdentifier.Mobile
{
    public class LivestockBrandService
    {
        private readonly RestClient _client;

        public LivestockBrandService()
        {
            _client = new RestClient(@"http://10.22.55.129:8080/api/livestockbrand/filter");
        }

        public SearchResultModel<LivestockBrandModel> Search(LivestockBrandSearchModel search)
        {
            var result = _client.PostAsync<SearchResultModel<LivestockBrandModel>, LivestockBrandModel>(search);

            return result.Result;
        }

        public ObservableCollection<LivestockBrandClassificationModel> SearchImage(string base64string)
        {
            var model = new LivestockBrandClassificationModel { ImageData = base64string, ProbabilityThreshold = 0.01 };
            var result = _client.PostAsync<ObservableCollection<LivestockBrandClassificationModel>, LivestockBrandClassificationModel>(model);

            return result.Result;
        }
    }
}
