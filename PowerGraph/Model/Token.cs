using System;

namespace PowerGraph.Model
{
    /// +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    /// ++ New-PGSession
    /// +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public class RequestToken
    {
        public String client_id;
        public String client_secret;
        public String grant_type;
        public String scope;
    }

    public class ResponseToken
    {
        public String token_type;
        public String expires_in;
        public String ext_expires_in;
        public String expires_on;
        public String not_before;
        public String resource;
        public String access_token;
    }
}
