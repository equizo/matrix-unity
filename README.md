# WIP
# matrix-unity
Matrix screensaver. Pure strings manipulation, no Unity transform operations. YT video:
[![](https://i.imgur.com/inpPHZ7.png)](https://youtu.be/2bRY7nReeI4)

## Algorithm
Based on cascades, where each cascade is a string of a randomized length, "following" from the top, which has the characters shifted with each update; Rendering is done with scanning each row and checking wether the cascades in the rowhave the .
Each character is a string that holds rich text color tag carrying the color.

## Project
GameBootstrapper.cs

## Alphabet
Original character set is a subset of Katakana
https://scifi.stackexchange.com/questions/137575/is-there-a-list-of-the-symbols-shown-in-the-matrixthe-symbols-rain-how-many
Represented as a a string of characters ﾊﾐﾋｰｳｼﾅﾓﾆｻﾜﾂｵﾘｱﾎﾃﾏｹﾒｴｶｷﾑﾕﾗｾﾈｽﾀﾇﾍ0123456789<>.=*+-

## Font
Font used RelaxedTypingMonoJP-Medium SDF
Japanese Monospace, thx to SHIODA Masaharu
https://github.com/mshioda/relaxed-typing-mono-jp

## Configuration
