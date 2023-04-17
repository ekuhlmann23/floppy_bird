namespace FloppyBird.UseCases.Pipes
{
    public interface IPipeUseCase
    {
        public void DamageBird();

        public void MovePipe(float deltaTime);

        public void AwardPointsToBird();
    }
}
