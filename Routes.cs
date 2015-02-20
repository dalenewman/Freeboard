using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using Orchard.Mvc.Routes;

namespace Freeboard {

    public class Routes : IRouteProvider {
        private const string ModuleName = "Freeboard";

        public void GetRoutes(ICollection<RouteDescriptor> routes) {
            foreach (var routeDescriptor in GetRoutes())
                routes.Add(routeDescriptor);
        }

        public IEnumerable<RouteDescriptor> GetRoutes() {
            return new[] {
                new RouteDescriptor {
                    Priority = 11,
                    Route = new Route(
                        "Modules/"+ModuleName+"/{id}",
                        new RouteValueDictionary { {"area", ModuleName}, {"controller", ModuleName}, {"action", "Index"} },
                        new RouteValueDictionary(),
                        new RouteValueDictionary { {"area", ModuleName} },
                        new MvcRouteHandler()
                    )
                },
                new RouteDescriptor {
                    Priority = 11,
                    Route = new Route(
                        "Freeboard/Save",
                        new RouteValueDictionary { {"area", ModuleName}, {"controller", ModuleName}, {"action", "Save"}},
                        new RouteValueDictionary(),
                        new RouteValueDictionary { {"area", ModuleName} },
                        new MvcRouteHandler()
                    )
                },
                new RouteDescriptor {
                    Priority = 11,
                    Route = new Route(
                        "Freeboard/Load/{id}",
                        new RouteValueDictionary { {"area", ModuleName}, {"controller", ModuleName}, {"action", "Load"}},
                        new RouteValueDictionary(),
                        new RouteValueDictionary { {"area", ModuleName} },
                        new MvcRouteHandler()
                    )
                }
            };
        }
    }
}