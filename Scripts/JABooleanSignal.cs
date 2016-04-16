// The MIT License (MIT)
//
// Copyright (c) 2015 Jabavu W. Adams.
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.


// JABooleanSignal
//
// Assume that you have some boolean value or condition that you check
// periodically. In addition to checking the current value, you want to
// be able to detect whether the value changed from its previous value.
// BooleanSignal encapsulates the common pattern of having a current value
// and a previous value. It provides properties that can be used to detect
// false->true and true->false transitions.


public class JABooleanSignal
{
    // What is the value now?
    private bool m_currentValue;

    // What was the value before the current value?
    private bool m_previousValue;


    // Default constructor sets signal to false.
    public JABooleanSignal()
    {
	Clear();
    }


    public bool CurrentValue
    {
	get { return m_currentValue; }
    }


    public bool PreviousValue
    {
	get { return m_previousValue; }
    }

    // Is the current value different from the previous value?
    public bool ValueChanged
    {
	get { return m_currentValue != m_previousValue; }
    }

    // Did the signal transition from false to true?
    public bool RisingEdge
    {
	get { return m_currentValue && !m_previousValue;}
    }

    // Did the signal transition from true to false?
    public bool FallingEdge
    {
	get { return !m_currentValue && m_previousValue; }
    }

    // Automatically convert this object to a boolean. This is
    // so that you can write code like:
    //
    //	private BooleanSignal isJumping;
    //
    //	if (isJumping)
    //	{
    //		// ...
    //		}

    public static implicit operator bool(JABooleanSignal signal)
    {
	return signal.CurrentValue;
    }

    public void Clear()
    {
	m_previousValue = false;
	m_currentValue = false;
    }

    // This is how you update the current value.
    public void AppendValue(bool newValue)
    {
	m_previousValue = m_currentValue;
	m_currentValue = newValue;
    }
}
