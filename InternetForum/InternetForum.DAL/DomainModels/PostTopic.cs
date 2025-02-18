namespace InternetForum.DAL.DomainModels
{
    public class PostTopic
    {
        public string PostId { get; set; }
        public Post Post { get; set; }
        public string TopicId { get; set; }
        public PostTopic MyProperty { get; set; }
    }
}
