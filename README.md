# ChsWords

Takes publication which is in PDF written in Chinese including pinyin and converts it into list of used words ordered by frequency of occurrence in the text.

## Steps 1
Manual copy paste from the pdf publication into a txt file.

Copy pasted text usually looks something like this:
>现在
>xiànz ài
>就
>jiù
>该
>gāi
>这么
>zhème
>做
>zuò
>。 另外
>Lìngw ài

Spaces and new lines can appear anywhere in the text even in the middle of a word. Additionally text contains other characters (dots, commas, ...) which should not appear in the final list of words.

## Step 2
Run the program supplying the txt file as a argument.
Excel file will be generated with the list.
Each row includes followong columns:
Hanzi (Chinese word), Pinyin, Translation (left empty for user to populate), Percentage, Cumulative percentage 

## Parameters
####inputFileName
Required parameter. Specify path adn file name for the txt file which has been populated by the values copy pasted from the original pdf file.

####outputFileName
Optional parameter. If no value has been supplied, the resulting file will be called *result.xlsx*

####-open
Optiona lparameter. When this parameter has been supplied, the generated xlsx file will be open automatically at the end of the process. 
