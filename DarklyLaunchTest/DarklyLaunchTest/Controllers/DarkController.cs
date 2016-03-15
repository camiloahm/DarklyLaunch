using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using LaunchDarkly.Client;

namespace DarklyLaunchTest.Controllers
{
    public class DarkController : ApiController
    {
        LdClient ldClient = new LdClient("sdk-dbcb098d-e73c-4e8c-a8ad-be496789dfa9");
        User user = new User("juan.giraldo@gmail.com");

        // GET: api/Dark
        public async Task<bool> Get()
        {
            bool result = await TakeTimeToExecution(GetToggle, (x) => Trace.TraceInformation(x));

            return result;
        }

        private static async Task<T> TakeTimeToExecution<T>(Func<Task<T>> func, Action<string> log)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            T t = await func();
            stopwatch.Stop();
            log("XXXXXXXXXXXX Time:"+stopwatch.Elapsed.Milliseconds.ToString());

            return t;
        }


        private async Task<bool> GetToggle()
        {
            user.Country = "Colombia";
            bool showFeature = await ldClient.Toggle("something", user, false);
            if (showFeature)
            {
                // application code to show the feature 
            }
            else
            {
                // the code to run if the feature is off
            }
            return showFeature;
        }

        // GET: api/Dark/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Dark
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Dark/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Dark/5
        public void Delete(int id)
        {
        }
    }
}