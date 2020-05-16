using Xunit;

namespace ValueReference.Tests
{
    public class ReferenceTypeTests
    {
        [Fact]
        public void StringRemainsUnchangedUnlessReassigned()
        {
            var name = "scott";
            MakeUpper(name);
            Assert.NotEqual("SCOTT", name);
        }
        
        [Fact]
        public void StringReassignedShowsNewChanges()
        {
            var name = "scott";
            name= MakeUpperCase(name);
            Assert.Equal("SCOTT", name);
        }
        [Fact]
        public void StringNotReassignedButShowsNewChanges()
        {
            var name = "scott";
           MakeUpperCase(ref name);
            Assert.Equal("SCOTT", name);
        }
        
        [Fact]
        public void StringExtensionMethodsAlwaysReturnNewInstanceOfStringEvenThoughPassedByRef()
        {
            var name = "scott";
           MakeToUpperCase(ref name);
            Assert.NotEqual("SCOTT", name);
        }

      [Fact]  public void CanModifyNameFromReference()
        {
            var newName = "New Name";
            var objectInstance = CreateNewType("TypeOne");
            SetValueByRef(ref  objectInstance, newName);
            Assert.Equal(objectInstance.Name, newName);
        }
      
      [Fact]  public void CannotModifyReferenceTypeFromValue()
        {
            var newName = "New Name";
            var actual = "TypeOne";
            var objectInstance = CreateNewType("TypeOne");
            SetValueByValue( objectInstance, newName);
            Assert.NotEqual(objectInstance.Name, newName);
            Assert.Equal(objectInstance.Name, actual);
        }
      
        
        
        
        
        private string MakeUpperCase(string name)
        {
            return name.ToUpper();
        }
        private void MakeUpper(string name)
        {
             name.ToUpper();
        } 
        private string MakeUpperCase(ref string name)
        {
            //unless reassigned the resulting string from the ToUpper Operation does not affect the same reference instance
           return  name=name.ToUpper();
        }
        private string MakeToUpperCase(ref string name)
        {
           return  name.ToUpper();
        }

        ReferenceType CreateNewType(string name)
        {
            return new ReferenceType(name);
        }
        
        private void SetValueByValue(ReferenceType instance, string value)
        {
            instance= new ReferenceType(value);
        }
        private void SetValueByRef(ref ReferenceType instance,string value)
        {
            instance= new ReferenceType(value);
        }
    }
}