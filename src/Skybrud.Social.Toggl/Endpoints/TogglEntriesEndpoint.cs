using Skybrud.Essentials.Time;
using Skybrud.Social.Toggl.Endpoints.Raw;
using Skybrud.Social.Toggl.Responses;
using Skybrud.Social.Toggl.Responses.Entries;

namespace Skybrud.Social.Toggl.Endpoints {

    public class TogglEntriesEndpoint {

        #region Properties

        public TogglService Service { get; }

        public TogglEntriesRawEndpoint Raw { get; }

        #endregion

        #region Constructors

        public TogglEntriesEndpoint(TogglService service) {
            Service = service;
            Raw = service.Client.Entries;
        }

        #endregion

        #region Member methods

        public TogglEntriesResponse GetEntries(EssentialsTime startDate, EssentialsTime endDate) {
            return TogglEntriesResponse.Parse(Raw.GetEntries(startDate, endDate));
        }

        #endregion

    }

}