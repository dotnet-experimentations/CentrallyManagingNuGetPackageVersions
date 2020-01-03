using System.Collections.Generic;

namespace Foo
{
    public class FooBarOptions
    {
        public Dictionary<int, string> Mappings { get; set; } =
            new Dictionary<int, string>
            {
                { 3, "foo"},
                { 5, "bar"},
            };
    }
}
