using System.Net;

namespace CommitZeroBack.Tools {
    public static class IpGetter {
        public static string Get() {
            WebClient webClient = new WebClient();
            string publicIp = webClient.DownloadString("https://api.ipify.org");
            return publicIp;
        }
    }
}