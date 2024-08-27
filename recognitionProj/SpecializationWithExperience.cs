namespace recognitionProj;
public class SpecializationWithExperience
{
    private Specialization _specialization;
    private int _yearsOfExperience;

    public Specialization Specialization
    {
        get { return _specialization; }
        set { _specialization = value; }
    }

    public int YearsOfExperience
    {
        get { return _yearsOfExperience; }
        set { _yearsOfExperience = value; }
    }

    public SpecializationWithExperience(Specialization specialization, int yearsOfExperience)
    {
        _specialization = specialization;
        _yearsOfExperience = yearsOfExperience;
    }
}
