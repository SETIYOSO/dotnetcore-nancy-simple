using System;
using Nancy;

namespace NancyApplication.Module
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get("/", args => "Hello World. This is pretty cool!");                        
			Get("/test", args => $"Hello {this.Request.Query["name"]}"); // Test with http://localhost:5000/test?name=Foo
            Get("/test/{name}", args => new Person() { Name = args.name });  // Test with http://localhost:5000/test/Foo
            Get("/test2/{name}", args => $"Hello {args.name}"); // Test with http://localhost:5000/test2/Foo
            Get("/test3/{name}", args => MethodName3(args));
            Get("/test4", args => Method4(args));

        }

        /// <summary>
        /// Description
        /// </summary>
        private dynamic Method4(dynamic obj)
        {
            return String.Format("Hello {0}", this.Request.Query["name"]);
        }
        /// <summary>
        /// Description
        /// </summary>
        public dynamic MethodName3(dynamic obj)
        {
            return String.Format("Hello {0}", obj.name);
        }
        
    }

    public class Person
    {
        public string Name { get; set; }
    }
}
