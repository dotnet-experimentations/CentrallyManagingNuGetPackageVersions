using Microsoft.Extensions.Options;

namespace Foo
{
    public class FooBar : IFooBar
    {
        private readonly FooBarOptions _options;

        public FooBar(IOptions<FooBarOptions> options)
        {
            _options = options.Value;
        }

        public string Compute(int value)
        {
            string result = null;
            foreach (var mapping in _options.Mappings)
            {
                if (value % mapping.Key == 0)
                {
                    result += mapping.Value;
                }
            }

            return result ?? value.ToString();
        }
    }
}
