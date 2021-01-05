using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Parser
{
    public class ParserJson
    {
        public void SerializeJson(List<Login> logins)
        {
            FixUsers(logins);

            foreach (var login in logins)
            {
                Directory.CreateDirectory($".\\Config\\{login.Name}");
                var jsonLogin = JsonConvert.SerializeObject(login);

                using (var st = new StreamWriter($".\\Config\\{login.Name}\\{login.Name}.json"))
                {
                    st.Write(jsonLogin);
                }
            }
        }

        private void FixUsers(List<Login> logins)
        {
            foreach (var item in logins)
            {
                item.Fix();
            }
        }
    }
}
