using System;

namespace LibraryApi.Utils
{
    public class IdentifierGenerator : IGeneratorIds
    {
        public Guid GetEnrollmentId()
        {
            return Guid.NewGuid();
        }
    }
}
