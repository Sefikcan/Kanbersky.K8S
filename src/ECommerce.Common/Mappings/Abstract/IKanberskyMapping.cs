namespace ECommerce.Common.Mappings.Abstract
{
    /// <summary>
    /// 
    /// </summary>
    public interface IKanberskyMapping
    {
        // <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        TDestination Map<TSource, TDestination>(TSource source);
    }
}
