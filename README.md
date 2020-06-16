# YouTube subtitles To .SRT  
Problem: 
User published a video to YouTube as well as created subtitles (either upploaded external file or used YouTube Studio).
Later user decided to cut a piece of video so all time codes going after deleted segment need to be shifted backwards.
As a user I need a mechanism to fix subtitles and update subtitles on YouTube.

Proposed solution:
Going entire path using current tool is unsupported right now.

As of now YouTube supports following formats (https://support.google.com/youtube/answer/2734698), including .srt.
1. Get current subtitles
Go to YouTube Studio -> Subtitles -> Actions -> Download
Which will result in data in following format:
00:00:00.0,00:00:01.00
Track 1
00:00:01.00,00:00:05.00
Track 2
00:00:05.00,00:00:07.00
Track 3

2. Convert into .srt format.
Create file named 'source.txt' of that data and run current tool to convert it into .srt format.
Expected output:
1
00:00:00.0 --> 00:00:01.00
Track 1
2
00:00:01.00 --> 00:00:05.000
Track 2
3
00:00:05.00 --> 00:00:07.000
Track 3

3. Prepare Data
Suppose, on Youtube you removed a block of video from second 1 to 5 (corresponds to 'Track 2')
Copy resulted .srt file so that it started with deleted segment (don't worry about segment indexes):
2
00:00:01.00 --> 00:00:05.000
Track 2
3
00:00:05.00 --> 00:00:07.000
Track 3

4. Shift Segments
Use SubShifter (https://subshifter.bitsnbites.eu) online SRT Subtitle Resunc Tool.
Use file created on previous step.
Specify negative Time Shift equal to the duration of removed 'Track 2' segment: '-4.0' (Track 3 started on second 5, we want it an second 1).
Click 'Resync' button and get timecode shift result.

5. Merge files received on Step 3 and Step 4 manually, I know :(
6. Reload Subtitles on YoutTube
Go to YouTube Studio -> Subtitles -> Actions -> Upload.
This should overwrite existing subtitles and closed captions.

7. Review.
If anything seems wrong, either repeat a shift operation with proper duration or upload back on YouTube original file which you downloaded on Step 1.

## License
Please see [LICENSE.md](LICENSE.md).

### How it looks right now

[![Snake](https://img.youtube.com/vi/RRwygd_7nsk/0.jpg)](https://www.youtube.com/watch?v=RRwygd_7nsk)

## Contact
You can reach me via my [email](mailto://denis.golovin@gmail.com).