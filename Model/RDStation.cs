using System.Collections.Generic;

namespace ServiceLayer.Model
{
    public class RDStation
    {
        public string token { get; set; }
        public Organization organization { get; set; }

    }

    public class Organization
    {
        public string name { get; set; }
        public string user_id { get; set; }
        public string resume { get; set; }
        public IList<string> organization_segments { get; set; }
        public IList<OrganizationCustomField> organization_custom_fields { get; set; }

    }

    public class OrganizationCustomField
    {
        public string custom_field_id { get; set; }
        public string value { get; set; }
    }

}
