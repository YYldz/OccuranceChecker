# OccuranceChecker
Check for occurance of the letters AGCT in another string that's at least as long as the first string.
Sentences are split with a space.
For example, this would be a correct way to input something into the console: AGT AGAGAGAGAGT
It will then compare String 1 (AGT) to String 2 (AGAGAGAGAGT)
The three numbers are different checks,

Type 1: String 1, without any changes.
Type 2: All unique strings that can be made by deleting one character from String 1 (for example, AGC can become AG, AC, or GC).
Type 3: All unique strings that can be made by inserting one character in String 1 (for example, AG can become any of the following: AAG, GAG, CAG, TAG, AGG, ACG, ATG, AGA, AGC, or AGT).
If two or more different modifications of SS result in the same string, count only the occurrences of that string once.

Sample:

Sample Input 1	
AGCT AGCTAGCT
AAA AAAAAAAAAA
AGC TTTTGT
0

Sample Output 1
2 4 2
8 9 7
0 0 0
