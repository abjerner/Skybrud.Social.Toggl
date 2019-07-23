using System;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Time;
using Skybrud.Social.Toggl.Http;

namespace Skybrud.Social.Toggl.Endpoints.Raw {

    public class TogglEntriesRawEndpoint {

        #region Properties

        public TogglHttpClient Client { get; }

        #endregion

        #region Constructors

        public TogglEntriesRawEndpoint(TogglHttpClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        public IHttpResponse GetEntries() {
            return Client.DoHttpGetRequest("/api/v8/time_entries");
        }

        public IHttpResponse GetEntries(EssentialsTime startDate, EssentialsTime endDate) {
            if (startDate == null) throw new ArgumentNullException(nameof(startDate));
            if (endDate == null) throw new ArgumentNullException(nameof(endDate));
            return Client.DoHttpGetRequest("/api/v8/time_entries", new HttpQueryString {
                {"start_date", startDate.ToString(TimeUtils.Iso8601DateFormat)},
                {"end_date", endDate.ToString(TimeUtils.Iso8601DateFormat)}
            });
        }

        #endregion

    }

}