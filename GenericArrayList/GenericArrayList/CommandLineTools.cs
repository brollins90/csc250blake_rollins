using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakingLists
{
	class CommandLineTools
	{
		public static bool updateProgressBar(int iteration, int maxIterator, int barLength)
		{
			return (iteration % (maxIterator / barLength) == 0) // mid bar
				|| (barLength > maxIterator)
				|| iteration == maxIterator - 1 // bar is complete
				|| iteration == 0;
		}
		public static void PrintProgressBar(int location, int iteration, int maxIterator, int barLength, bool playNoise = false)
		{
			if (updateProgressBar(iteration, maxIterator, barLength))
			{
				const int finishedFreq = 1500;
				const int finishedLength = 500;
				const int lowFreq = 500;
				const int highFreq = 1000;
				const int intervalLength = 100;

				StringBuilder progressBar = new StringBuilder();
				char head = (char)16;//'>';
				char completedHead = (char)21;//'^';
				char leftBar = (char)166;//'|';
				char rightBar = (char)166;//'|';
				char body = '-';
				char background = ' ';
				float percent = (float)iteration / (float)maxIterator;

				if (playNoise)
				{
					int freqToPlay = (int)(percent * (highFreq - lowFreq) + lowFreq);
					Console.Beep(freqToPlay, intervalLength);
				}

				int headPos = 0;

				progressBar.Append(leftBar);

				int numOfFull = (int)(percent * (barLength - 2));
				int remaining = (barLength - 2) - numOfFull;
				progressBar.Append(new string(body, numOfFull));
				progressBar.Append(new string(background, remaining));

				headPos = numOfFull;

				progressBar.Append(rightBar);

				if (iteration != maxIterator - 1)
				{
					progressBar[headPos + 1] = head;
				}
				else
				{
					progressBar[headPos + 1] = completedHead;
					if (playNoise)
					{
						Console.Beep(finishedFreq, finishedLength);
					}
				}
				Console.SetCursorPosition(0, location);//reset to beginning of the line;
				Console.Write(progressBar);
			}
		}
	}
}
