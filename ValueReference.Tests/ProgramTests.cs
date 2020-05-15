using System;
using Xunit;

namespace ValueReference.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void InitialValueShouldBeFiftyEvenThoughModifiedByUpdateValue()
        {
            int initialValue = 50;
            ValueReference.Program.UpdateValue(50);
            Assert.Equal(50,initialValue);
        } 
        
        
       
        
        
        
      [Fact]  public void InitialValueShouldBeModified()
        {
            int initialValue = 50;
            ValueReference.Program.UpdateValue(ref initialValue);
            Assert.NotEqual(50,initialValue);
        }

    [Fact] public void InitialValueShouldHaveTheValueSetInTheInnerScopeByReference()
      {
          int innerScopeValue = 100;
          int initialValue = 50;
          ValueReference.Program.UpdateValue(ref initialValue);
          Assert.Equal(innerScopeValue, initialValue);
        }
    }
}
