using Newtonsoft.Json;
using System.Collections.Generic;

namespace AuthTest.Code.Json
{

    public class Group
    {
        public string groupId;
        public List<string> roles;
    }
    public class Root
    {
        public List<string> scopes;
        public List<Group> groups;
    }

    class JsonHelper
    {
        /// <summary>
        /// GetJsonObject
        /// </summary>
        /// <returns></returns>
        public static string GetJsonObject()
        {
            var root = new Root()
            {
                scopes = new List<string> { "group_manages", "group_creates" },
                groups = new List<Group> { new Group { groupId = "auth_adminss", roles = new List<string>() { "auth_admins" } } }

            };

            var jsonString = JsonConvert.SerializeObject(root);
            return jsonString;
        }
    }
}