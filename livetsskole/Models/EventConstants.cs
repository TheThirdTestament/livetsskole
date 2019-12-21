using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace livetsskole.Models
{
    public class EventConstants
    {

        /// <summary>
        /// Gets the numeric ID of the backoffice user that should be responsible for import actions.
        /// </summary>
        public const int ImportUserId = 1;

        public static class Content
        {

            /// <summary>
            /// Gets the numeric ID of the <strong>Products</strong> content item.
            /// </summary>
            public const int Products = 1107;

        }

        public static class Media
        {

            /// <summary>
            /// Gets the numeric ID of the <strong>Products</strong> media folder.
            /// </summary>
            public const int Products = 1132;

        }

        public static class ContentTypes
        {

            /// <summary>
            /// Gets the alias of the <strong>Product</strong> content type.
            /// </summary>
            public const string Product = "product";

        }
    }    
}