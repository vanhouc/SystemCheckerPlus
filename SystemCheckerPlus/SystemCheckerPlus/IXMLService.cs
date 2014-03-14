namespace SystemCheckerPlus
{
    public interface IXMLService
    {
        Application[] GetAppData(string[] elementChain);

        string[] GetChildValues(string[] elementChain, string childProperty);

        string GetElementValue(string[] elementChain);
    }
}