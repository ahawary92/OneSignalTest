using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain
{
    public class App
    {
        public string name { get; set; }
        public string apns_env { get; set; }
        public string apns_p12 { get; set; }
        public string apns_p12_password { get; set; }
        public string gcm_key { get; set; }
        public string android_gcm_sender_id { get; set; }
        public string chrome_web_origin { get; set; }
        public string chrome_web_default_notification_icon { get; set; }
        public string chrome_web_sub_domain { get; set; }
        public string safari_apns_p12 { get; set; }
        public string safari_apns_p12_password { get; set; }
        public string site_name { get; set; }
        public string safari_site_origin { get; set; }
        public string safari_icon_256_256 { get; set; }
        public string chrome_key { get; set; }
        public bool additional_data_is_root_payload { get; set; }
        public string organization_id { get; set; }
    }
}
