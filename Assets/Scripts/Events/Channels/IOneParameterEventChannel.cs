namespace FloppyBird.Events.Channels
{
    public interface IOneParameterEventChannel<in TParam>
    {
        public void RaiseEvent(TParam param);
    }
}
