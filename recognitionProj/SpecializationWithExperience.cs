namespace recognitionProj;
public class SpecializationWithExperience//this class is here to put the amount of years of experience next to the spec
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

    public override string ToString()
    {
        return _specialization.Name + " with " + _yearsOfExperience + " years of experience";
    }
}
