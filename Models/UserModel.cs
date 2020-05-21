// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Graph;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace b2c_ms_graph
{
    public class UserModel : User
    {
        [JsonProperty(PropertyName = "password", NullValueHandling = NullValueHandling.Ignore)]
        public string Password { get; set; }
        
        [UIHint("CustomerLookup")]
        public string extension_39d2bd21d67b480891ffa985c6eb1398_CustomerNumber { get; set; }

        public int extension_39d2bd21d67b480891ffa985c6eb1398_WebRole { get; set; }

        public string extension_39d2bd21d67b480891ffa985c6eb1398_TenantId { get; set; }

        [UIHint("CompanyLookup")]
        public string extension_39d2bd21d67b480891ffa985c6eb1398_CompanyId { get; set; }

        public string newPassword { get; set; }

        public string confirmPassword { get; set; }

        public bool forcePasswordChange { get; set; }

        public bool DisplayAccountEnabled { get; set; }

        public string DisplayEmailName { get; set; }

        public void SetB2CProfile(string TenantName)
        {
            this.PasswordProfile = new PasswordProfile
            {
                ForceChangePasswordNextSignIn = false,
                Password = this.Password,
                ODataType = null
            };
            this.PasswordPolicies = "DisablePasswordExpiration,DisableStrongPassword";
            this.Password = null;
            this.ODataType = null;

            foreach (var item in this.Identities)
            {
                if (item.SignInType == "emailAddress" || item.SignInType == "userName")
                {
                    item.Issuer = TenantName;
                }
            }
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }   
    }
}