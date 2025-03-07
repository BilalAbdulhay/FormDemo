using FormDemo.Models;

namespace FormDemo
{
   public partial class Form1 : Form
   {
      public Form1()
      {
         InitializeComponent();
      }
      private List<string> PrepData()
      {
         List<string> outPut = new List<string>();
         textBox1.Text = "";

         outPut.Add("https://www.yahoo.com");
         outPut.Add("https://www.google.com");
         outPut.Add("https://www.microsoft.com");
         outPut.Add("https://www.cnn.com");
         outPut.Add("https://www.codeproject.com");
         outPut.Add("https://www.stackoverflow.com");

         return outPut;
      }
      private void ReportWebsiteInfo(WebsiteDataModel data)
      => textBox1.Text += $"{data.websiteUrl} downloaded: {data.websiteData.Length} characters long.{Environment.NewLine}";




      private void NormalButton_Click(object sender,EventArgs e)
      {
         TotalTimeLabel.Text = "Total executed time :";
         var watch = System.Diagnostics.Stopwatch.StartNew();
         RunDownloadSync();

         watch.Stop();
         var elapsedMs = watch.ElapsedMilliseconds;
         TotalTimeLabel.Text += $"{elapsedMs}";
      }
      private void RunDownloadSync()
      {
         List<string> webSites = PrepData();
         foreach(var site in webSites)
         {
            WebsiteDataModel results = DownloadWebsite(site);
            ReportWebsiteInfo(results);
         }
      }
      private WebsiteDataModel DownloadWebsite(string webSiteUrl)
      {
         WebsiteDataModel output = new WebsiteDataModel();
         HttpClient client = new HttpClient();

         client.DefaultRequestHeaders.Add("User-Agent","Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");

         output.websiteUrl = webSiteUrl;
         output.websiteData = client.GetStringAsync(webSiteUrl).Result; //  ÕÊÌ· async ≈·Ï sync

         return output;
      }




      private async void AsyncButton_Click(object sender,EventArgs e)
      {
         TotalTimeLabel.Text = "Total executed time :";
         var watch = System.Diagnostics.Stopwatch.StartNew();
         await RunDownloadParallelAsync();

         watch.Stop();
         var elapsedMs = watch.ElapsedMilliseconds;
         TotalTimeLabel.Text += $"{elapsedMs}";
      }
      private async Task RunDownloadAsync()
      {
         List<string> webSites = PrepData();
         foreach(var site in webSites)
         {
            WebsiteDataModel results = await Task.Run(() => DownloadWebsiteAsync(site));
            ReportWebsiteInfo(results);
         }
      }
      private async Task RunDownloadParallelAsync()
      {
         List<string> webSites = PrepData();
         List<Task<WebsiteDataModel>> tasks = new List<Task<WebsiteDataModel>>();
         foreach(var site in webSites)
            tasks.Add(DownloadWebsiteAsync(site));

         var results = await Task.WhenAll(tasks);
         foreach(var item in results)
            ReportWebsiteInfo(item);
      }
      private async Task<WebsiteDataModel> DownloadWebsiteAsync(string webSiteUrl)
      {
         WebsiteDataModel output = new WebsiteDataModel();
         using(HttpClient client = new HttpClient())
         {
            try
            {
               output.websiteUrl = webSiteUrl;
               output.websiteData = await client.GetStringAsync(webSiteUrl);
            }
            catch(Exception ex)
            {
               output.websiteData = $"Error downloading {webSiteUrl}: {ex.Message}";
            }
         }
         return output;
      }


   }
}
