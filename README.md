# Very-Specific-Hitman-Roulette

A randomizer for making Hitman Contracts that's very specific. It will draw kill conditions not only from what available on the level currently, but you can also input your mastery and it will draw items from that as well.

## This Roulette isn't for main missions. Only Contracts.

Features
- Accounts for Mastery with kills.
- Saves your Mastery so you don't have to re-input each time
- Able to manually choose how many targets you want, can go up to 10.
- Generalized targets to allow players to choose whoever they'd like in their contract.

# USE:

To use this randomizer you need to first install Visual Studio Code 2022, then launch and open the SLN for HitmanRoulette in Visual Studio. Then simply just run the program at the top and wait.

Now, you will be asked to either create a profile or not. Included with the Github release are two profiles: "Snail", and "The Mafia" which is mine and AgentSnail's mastery levels respectively. You can type "Y" or "N" to either create or use an existing profile.

If you choose to create a profile you will be asked what DLC's you own, and your mastery on each level. Once input, all the information is saved to the "HitmanRoulette/bin/txt/Profiles" folder.

Then the randomizer will ask you how many target's you'd like, this can be any number from 1 to 10.

Now it will randomize and give you that many target's, drawing kill conditions from the map it chose and also possible items you can bring with you at your current mastery. For example, if Mendoza was chosen, you might be asked to kill a Guard with the wine press, or with an Iceballer.

## Possible Bugs

Some notable bugs to consider:

- Sometimes has a small chance to tell you to kill a unique NPC more than once. Solution is to just re-spin.
- Might give you more than 4 Items that required to be imported into the map. This should be fixed but keep it in mind, i re-wrote the system it used for this.

NOTE: Spins above 5 targets are usually volatile and you won't be guranteed a functioning spin. It might contain both of the bugs mentioned above or something else stupid. Either re-spin or try a smaller number.