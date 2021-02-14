namespace DouCalendarService.Telegram.Service.Model
{
    public class ShortEvent
    {
        /// <summary>
        /// Id of event
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Link of event
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Name of event
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Image logo of event
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Date to pass event
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// Description of event
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Topic to relate event
        /// </summary>
        public string Topics { get; set; }

        /// <summary>
        /// Count of visitors to go on event
        /// </summary>
        public string CountOfVisitors { get; set; }

        /// <summary>
        /// Cost of event
        /// </summary>
        public string Price { get; set; }

        /// <summary>
        /// Place to pass event
        /// </summary>
        public string Place { get; set; }
    }
}
