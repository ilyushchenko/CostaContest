namespace BL.Repositories
{
    internal class Factory
    {
        private static CrmContext context;

        /// <summary>
        /// Предоставлет единый экземпляр контекста <see cref="CrmContext"/> 
        /// </summary>
        public static CrmContext Instance
        {
            get
            {
                if (context == null)
                {
                    context = new CrmContext();
                }
                return context;
            }

        }
    }
}
