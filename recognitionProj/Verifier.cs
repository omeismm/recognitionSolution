namespace recognitionProj;

public class Verifier
{
    private University _uni;
    private List<string> _message;
    private bool _verified;
    private bool _Article3;
    private bool _Article4;
    private bool _Article5;
    private bool _Article6;
    private bool _Article7;

    public Verifier(University uni)
    {
        _uni = uni;
        _message = new List<string>();
        _verified = false;
        _Article3 = false;
        _Article4 = false;
        _Article5 = false;
        _Article6 = false;
        _Article7 = false;

    }

    public List<string> Message // Change the type of Message to List<string>
    {
        get => _message;
        set => _message = value;
    }

    public University Uni
    {
        get => _uni;
        set => _uni = value;
    }

    public bool Article3
    {
        get => _Article3;
        set => _Article3 = value;
    }

    public bool Article4
    {
        get => _Article4;
        set => _Article4 = value;
    }

    public bool Article5
    {
        get => _Article5;
        set => _Article5 = value;
    }

    public bool Article6
    {
        get => _Article6;
        set => _Article6 = value;
    }

    public bool Article7
    {
        get => _Article7;
        set => _Article7 = value;
    }

    public bool Verified
    {
        get => _verified;
        set => _verified = value;

    }


    
    public void VerifyArticle3()
    {
        
    }

    public void VerifyArticle4()
    {
        
    }

    public void VerifyArticle5()
    {
        
    }

    public void VerifyArticle6()
    {
        
    }

    public void VerifyArticle7()
    {
        
    }

    public void Verify()
    {
        this.VerifyArticle3();
        this.VerifyArticle4();
        this.VerifyArticle5();
        this.VerifyArticle6();
        this.VerifyArticle7();
        if (_Article3 && _Article4 && _Article5 && _Article6 && _Article7)
        {
            _verified = true;
        }
    }




    
}
