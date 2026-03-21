using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using System.Text;

namespace GPS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {                        
            return View();
        }
        public JsonResult Gpslive()
        {
            string pullDatakey = "http://13.126.36.205/pullData/pullDataForUser1?token=eyJfaWQiOiI2NWI2MmEzNTFjMWNlMWZiZTk3NzIxMjEiLCJlbWFpbCI6Im5vRW1haWw0MTEyNzAiLCJwaG4iOiI5MDk1NzQ4NTkyIiwiZm4iOiJLYXJrYSIsImxuIjoiVGVjaG5vbG9naWVzIiwiZW1haWxfdmVyZmkiOnRydWUsInBob25lX3ZlcmZpIjp0cnVlLCJpc0RlYWxlciI6ZmFsc2UsIkRlYWxlcl9JRCI6eyJfaWQiOiI2MmIzMWJlZGNlZGU2YjVmYTdkZDQ3MTUiLCJmaXJzdF9uYW1lIjoiR0VPVFJBQ0tJTkciLCJsYXN0X25hbWUiOiJTT0xVVElPTlMiLCJlbWFpbCI6Imdlb3RyYWNraW5nc29sdXRpb25zQGdtYWlsLmNvbSIsInBob25lIjoiODc2NjI0MTYxOCJ9LCJpc09yZ2FuaXNhdGlvbiI6ZmFsc2UsImdyb3VwcyI6W10sImFjY291bnQiOiJLYXJrYSIsImV4cCI6MTcwNzkwMjAxNywic2Nob29sIjoiTkEiLCJzdXBBZG1pbiI6IjYyYjMxYmVkY2VkZTZiNWZhN2RkNDcxNSIsInN0YXR1cyI6dHJ1ZSwiaXNTdXBlckFkbWluIjpmYWxzZSwiaXNPcGVyYXRvciI6ZmFsc2UsImltYWdlRG9jIjpbXSwiZnVlbF91bml0IjoiTElUUkUiLCJyZXBvcnRfcHJlZmVyZW5jZSI6eyJub3RpZmljYXRpb25fbWFzdGVyIjp7IkFzdGF0dXMiOmZhbHNlLCJSc3RhdHVzIjp0cnVlfSwiZGFpbHlfbG9ncyI6eyJBc3RhdHVzIjpmYWxzZSwiUnN0YXR1cyI6dHJ1ZX0sIm1haW50YW5hbmNlX3JlcG9ydCI6eyJBc3RhdHVzIjpmYWxzZSwiUnN0YXR1cyI6dHJ1ZX0sIndvcmtpbmdfaG91cnNfcmVwb3J0Ijp7IkFzdGF0dXMiOmZhbHNlLCJSc3RhdHVzIjp0cnVlfSwibG9hZGluZ191bmxvYWRpbmdfdHJpcCI6eyJBc3RhdHVzIjpmYWxzZSwiUnN0YXR1cyI6dHJ1ZX0sImFsZXJ0X3JlcG9ydCI6eyJBc3RhdHVzIjpmYWxzZSwiUnN0YXR1cyI6dHJ1ZX0sInVzZXJfdHJpcF9yZXBvcnQiOnsiQXN0YXR1cyI6ZmFsc2UsIlJzdGF0dXMiOnRydWV9LCJkcml2ZXJfcGVyZm9ybWFuY2VfcmVwb3J0Ijp7IkFzdGF0dXMiOmZhbHNlLCJSc3RhdHVzIjp0cnVlfSwiYWNfcmVwb3J0Ijp7IkFzdGF0dXMiOmZhbHNlLCJSc3RhdHVzIjp0cnVlfSwic29zX3JlcG9ydCI6eyJBc3RhdHVzIjpmYWxzZSwiUnN0YXR1cyI6dHJ1ZX0sInBvaV9yZXBvcnQiOnsiQXN0YXR1cyI6ZmFsc2UsIlJzdGF0dXMiOnRydWV9LCJkaXN0YW5jZV9yZXBvcnQiOnsiQXN0YXR1cyI6ZmFsc2UsIlJzdGF0dXMiOnRydWV9LCJpZ25pdGlvbl9yZXBvcnQiOnsiQXN0YXR1cyI6ZmFsc2UsIlJzdGF0dXMiOnRydWV9LCJzdG9wcGFnZV9yZXBvcnQiOnsiQXN0YXR1cyI6ZmFsc2UsIlJzdGF0dXMiOnRydWV9LCJyb3V0ZV92aW9sYXRpb25fcmVwb3J0Ijp7IkFzdGF0dXMiOmZhbHNlLCJSc3RhdHVzIjp0cnVlfSwib3ZlcnNwZWVkX3JlcG9ydCI6eyJBc3RhdHVzIjpmYWxzZSwiUnN0YXR1cyI6dHJ1ZX0sImdlb2ZlbmNlX3JlcG9ydCI6eyJBc3RhdHVzIjpmYWxzZSwiUnN0YXR1cyI6dHJ1ZX0sInN1bW1hcnlfcmVwb3J0Ijp7IkFzdGF0dXMiOmZhbHNlLCJSc3RhdHVzIjp0cnVlfSwidHJhdmVsX3BhdGhfcmVwb3J0Ijp7IkFzdGF0dXMiOmZhbHNlLCJSc3RhdHVzIjp0cnVlfSwidHJpcF9yZXBvcnQiOnsiQXN0YXR1cyI6ZmFsc2UsIlJzdGF0dXMiOnRydWV9LCJmdWVsX2NvbnN1bXB0aW9uX3JlcG9ydCI6eyJBc3RhdHVzIjpmYWxzZSwiUnN0YXR1cyI6dHJ1ZX0sImlkbGVfcmVwb3J0Ijp7IkFzdGF0dXMiOmZhbHNlLCJSc3RhdHVzIjp0cnVlfSwiZnVlbF9yZXBvcnQiOnsiQXN0YXR1cyI6ZmFsc2UsIlJzdGF0dXMiOnRydWV9LCJzcGVlZF92YXJpYXRpb24iOnsiQXN0YXR1cyI6ZmFsc2UsIlJzdGF0dXMiOnRydWV9LCJkYXl3aXNlX3JlcG9ydCI6eyJBc3RhdHVzIjpmYWxzZSwiUnN0YXR1cyI6dHJ1ZX0sImRhaWx5X3JlcG9ydCI6eyJBc3RhdHVzIjpmYWxzZSwiUnN0YXR1cyI6dHJ1ZX19LCJkYXNoYm9hcmRfY29sdW1uIjp7Imlnbml0aW9uTG9jayI6dHJ1ZSwiZ3BzX2NvbHVtbiI6dHJ1ZSwiYWNfY29sdW1uIjp0cnVlLCJwb3dlcl9jb2x1bW4iOnRydWUsImdzbV9jb2x1bW4iOnRydWUsImlnbml0aW9uX2NvbHVtbiI6dHJ1ZSwiZXh0X3ZvbHQiOmZhbHNlLCJkb29yX2NvbHVtbiI6ZmFsc2UsInRlbXBfY29sdW1uIjpmYWxzZSwiY2hhcmdpbmdfY29sdW1uIjpmYWxzZSwiYWRkcmVzcyI6ZmFsc2V9LCJsYW5ndWFnZV9jb2RlIjoiZW4iLCJkZXZpY2VfYWRkX3Blcm1pc3Npb24iOnRydWUsImN1c3RfYWRkX3Blcm1pc3Npb24iOnRydWUsImt5Y0FwcHJvdmFsIjpmYWxzZSwiYnVzc2luZXNzVHlwZSI6IjAiLCJpYXQiOjE3MDcyOTcyMTd9";
            WebClient webClient = new WebClient();
            var value = webClient.DownloadData(pullDatakey);
            var sResponse = Encoding.UTF8.GetString(value);
            var jsonData = JsonConvert.DeserializeObject<VehicleDate>(sResponse);
            return Json(jsonData, JsonRequestBehavior.AllowGet);            
        }
        public class VehicleDate
        {
            public List<Device> Devices { get; set; }
        }
        public class Device
        {
            public string Device_Name { get; set; }
            public string Device_ID { get; set; }
            public LastLocation last_location { get; set; }
        }
        public class LastLocation
        {
            public double lat { get; set; }
            public double @long { get; set; }
        }

    }
}