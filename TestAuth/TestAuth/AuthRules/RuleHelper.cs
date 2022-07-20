using Newtonsoft.Json;
using System.Collections.Generic;

namespace TestAuth.AuthRules
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

    public class RuleHelper
    {
        /// <summary>
        /// GetRuleObject
        /// </summary>
        /// <returns></returns>
        public static string GetRuleObject()
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