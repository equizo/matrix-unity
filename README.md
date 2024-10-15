# WIP
# matrix-unity
Matrix screensaver. Pure strings manipulation, no Unity transform operations. YT video:
[![](https://i.imgur.com/inpPHZ7.png)](https://youtu.be/2bRY7nReeI4)

## Algorithm
It is based on cascades, where each cascade is a string of a randomized length, "following" from the top, which has the characters shifted with each update; rendering is done by scanning each row and checking whether the cascades in the row have the character to update in them.
Each character is a string that holds a rich text color tag.

## Project
GameBootstrapper.cs

## Alphabet
The original character set is a subset of Katakana
https://scifi.stackexchange.com/questions/137575/is-there-a-list-of-the-symbols-shown-in-the-matrixthe-symbols-rain-how-many
Represented as a string of characters ﾊﾐﾋｰｳｼﾅﾓﾆｻﾜﾂｵﾘｱﾎﾃﾏｹﾒｴｶｷﾑﾕﾗｾﾈｽﾀﾇﾍ0123456789<>.=*+-
Due to the nature of the charset and rain effect, 2 constraints arise preventing from having a custom charset: 1. font face must support Katakana; 2. font face must be of monospace family w/o dependency on the charset. This forces both font and charset to be hardcoded until a flexible configuration allows the selection of monospace font face and charset to be developed.

## Font
Font used RelaxedTypingMonoJP-Medium SDF
Japanese Monospace, thx to SHIODA Masaharu
https://github.com/mshioda/relaxed-typing-mono-jp

## Configuration
```Matrix_Data/StreamingAssets/config.yaml``` with the background color property being Out of Service.
