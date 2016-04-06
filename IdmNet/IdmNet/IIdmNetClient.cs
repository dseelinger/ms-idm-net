using System;
using System.Collections.Generic;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using IdmNet.Models;
using IdmNet.SoapModels;

namespace IdmNet
{
    public interface IIdmNetClient
    {
        /// <summary>
        /// Search the Identity Manager  (async await)
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<IEnumerable<IdmResource>> SearchAsync(SearchCriteria criteria, int pageSize = 50);

        /// <summary>
        /// Search the Identity Manager  (async await)
        /// </summary>
        /// <param name="criteria"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<PagedSearchResults> GetPagedResultsAsync(SearchCriteria criteria, int pageSize = 50);

        /// <summary>
        /// Pull resources from Identity Manager
        /// </summary>
        /// <param name="pageSize">Maximum number of records to return</param>
        /// <param name="pagingContext">Information regarding which records to pull</param>
        /// <returns>Paged search results</returns>
        /// <exception cref="SoapFaultException"></exception>
        Task<PagedSearchResults> GetPagedResultsAsync(int pageSize, PagingContext pagingContext);

        /// <summary>
        /// Get an object by its ID from Identity Manager (async await)
        /// </summary>
        /// <param name="objectID">Resource ID for the object to retrieve</param>
        /// <param name="selection"></param>
        /// <returns>Resource matching ObjectID</returns>
        Task<IdmResource> GetAsync(string objectID, List<string> selection);

        /// <summary>
        /// Get the number of Identity Manager resources that match the given XPath Filter.
        /// </summary>
        /// <param name="filter">Search filter</param>
        /// <returns>Number of matching resources</returns>
        Task<int> GetCountAsync(string filter);

        /// <summary>
        /// Create Object/Resource in Identity Manager Service  (async await)
        /// </summary>
        /// <param name="resource">Resource to be created</param>
        /// <returns>Resource with its newly assigned ObjectID</returns>
        Task<Message> CreateAsync(IdmResource resource);

        /// <summary>
        /// Delete an object in the Identity Manager service (async await)
        /// </summary>
        /// <param name="objectID">Resource ID for the object to be deleted</param>
        /// <returns></returns>
        Task<Message> DeleteAsync(string objectID);

        /// <summary>
        /// Add a value to a multi-valued attribute in the Identity Manager service  (async await)
        /// </summary>
        /// <remarks>
        /// While all attributes in an IdmResource are technically multi-valued, this method only works on attributes
        /// that are marked as multi-valued in the Identity Manager service.
        /// </remarks>
        /// <param name="objectID">Resource ID for the object containing the multi-valued attribute</param>
        /// <param name="attrName">Name of the Multi-Valued attribute to which a value will be added</param>
        /// <param name="attrValue">Value to be added to the Multi-Valued attribute</param>
        /// <returns>Task (async/await) of the asynchronous operation</returns>
        Task<Message> AddValueAsync(string objectID, string attrName, string attrValue);

        /// <summary>
        /// Remove a value from a multi-valued attribute in the Identity Manager service (async await)
        /// </summary>
        /// <remarks>
        /// While all attributes in an IdmResource are technically multi-valued, this method only works on attributes
        /// that are marked as multi-valued in the Identity Manager service.
        /// </remarks>
        /// <param name="objectID">Resource ID for the object containing the multi-valued attribute</param>
        /// <param name="attrName">Name of the Multi-Valued attribute from which a value will be removed</param>
        /// <param name="attrValue">Value to be removed from the Multi-Valued attribute</param>
        /// <returns>Task (async/await) of the asynchronous operation</returns>
        Task<Message> RemoveValueAsync(string objectID, string attrName, string attrValue);

        /// <summary>
        /// Replace/Set the value for a single-valued attribute in the Identity Manager service (async await)
        /// </summary>
        /// <remarks>
        /// While all attributes in an IdmResource are technically multi-valued, this method only works on attributes
        /// that are marked as single-valued in the Identity Manager service.
        /// </remarks>
        /// <param name="objectID">Resource ID for the object containing the single-valued attribute</param>
        /// <param name="attrName">Name of the Single-Valued attribute which will have its value set/replaced</param>
        /// <param name="attrValue">Value to be set for the Single-Valued attribute</param>
        /// <returns>Task (async/await) of the asynchronous operation</returns>
        Task<Message> ReplaceValueAsync(string objectID, string attrName, string attrValue);

        /// <summary>
        /// Make multiple changes to a particular Identity Manager service object/resource (async await)
        /// </summary>
        /// <param name="objectID">Resource ID for the object containing the attributes to be modified</param>
        /// <param name="changes">
        /// Set of changes (Multi-valued "Adds/Removes and Single-valued "Replaces" to be made for the single object
        /// </param>
        /// <returns>Task (async/await) of the asynchronous operation</returns>
        Task<Message> ChangeMultipleAttrbutes(string objectID, Change[] changes);

        /// <summary>
        /// Get the Schema associated with a particular object type
        /// </summary>
        /// <param name="objectType">Name of the object for which the schema should be retrieved</param>
        /// <returns>A fully populated ObjectTypeDescription object, including bindings for attributes</returns>
        Task<Schema> GetSchemaAsync(string objectType);

        /// <summary>
        /// Get the ObjectID for a newly created resource from the response message
        /// </summary>
        /// <param name="resourceCreationResponseMessage">Response message from the CreateAsync method</param>
        /// <returns>New object id</returns>
        string GetNewObjectId(Message resourceCreationResponseMessage);

        /// <summary>
        /// Approve or reject a particular request
        /// </summary>
        /// <param name="pendingApproval">A pending approval object - EndpointAddress and WorkflowInstance must be populated.</param>
        /// <param name="reason">Reason for approving or denying the request.</param>
        /// <param name="approve">If true, approve the request, otherwise reject</param>
        /// <returns>SOAP Message from the resulting Approval Response created.</returns>
        Task<Message> ApproveOrRejectAsync(Approval pendingApproval, string reason, bool approve);

        /// <summary>
        /// Approve a particular request
        /// </summary>
        /// <param name="pendingApproval">A pending approval object - EndpointAddress and WorkflowInstance must be populated.</param>
        /// <returns>SOAP Message from the resulting Approval Response created.</returns>
        Task<Message> ApproveAsync(Approval pendingApproval);

        /// <summary>
        /// Reject a particular request
        /// </summary>
        /// <param name="pendingApproval">A pending approval object - EndpointAddress and WorkflowInstance must be populated.</param>
        /// <returns>SOAP Message from the resulting Approval Response created.</returns>
        Task<Message> RejectAsync(Approval pendingApproval);

        /// <summary>
        /// Returns the Approval object for a given request
        /// </summary>
        /// <param name="requestObjectId">ObjectID for a given request that should have an approval associated with it.</param>
        /// <returns>An Approval object with both "EndpointAddress" and "WorkflowInstance" populated, or NULL if no Approvals exist for a given request</returns>
        Task<List<Approval>> GetApprovalsForRequest(string requestObjectId);

        /// <summary>
        /// Returns the ResourceReferenceProperty (eg. Approval ObjectID) associated with a particular message returned
        /// from an create/update-type operation
        /// </summary>
        /// <param name="soapMessageString">The SOAP message in a string format (msg.ToString())</param>
        /// <returns>The ObjectID of the associated resource/Approval, otherwise NULL</returns>
        /// <exception cref="NotImplementedException"></exception>
        string GetResourceReferenceProperty(string soapMessageString);
    }
}