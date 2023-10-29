# Very-Specific-Hitman-Roulette

A randomizer for making Hitman Contracts that's very specific. It will draw kill conditions not only from what available on the level currently, but you can also input your mastery and it will draw items from that as well.

## This Roulette isn't for main missions. Only Contracts.

Features
- Accounts for Mastery and owned DLC's with kills.
- Saves your Mastery so you don't have to re-input each time
- Able to manually choose how many targets you want, can go up to 15.
- Generalized targets to allow players to choose whoever they'd like in their contract.

# USE:

Head to HitmanRoulette\HitmanRoulette\bin\Debug\net6.0\
and launch HitmanRoulette.exe

This will launch the roulette, and that's it, you've got it working!

Now, you will be asked to either create a profile or not. Included with the Github release are two profiles: "All", and "None" which is a profile with everything possible unlocked and available, and one with the opposite respectively. You can type "Y" or "N" to either create or use an existing profile.

If you type "Y" and enter in an existing profile, it will let you view your current profile mastery and DLC privileges so you can confirm if everything is correct.

If you choose to create a profile you will be asked what DLC's you own, and your mastery on each level. Once input, all the information is saved to the "HitmanRoulette/bin/txt/Profiles" folder.

Then the randomizer will ask you how many target's you'd like, this can be any number from 1 to 15.

Now it will randomize and give you that many target's, drawing kill conditions from the map it chose and also possible items you can bring with you at your current mastery. For example, if Mendoza was chosen, you might be asked to kill a Guard with the wine press, or with an Iceballer. Imported items are capped to 2, so the player can have up to 2 items they must smuggle or start with.

# Impossible Spins

Spins above 5 targets are usually volatile and you won't be guranteed a functioning spin. It might contain impossible targets or too many items you must import. Or something else stupid. Either re-spin or try a smaller number. Hopefully with all the recent changes I've made this doesn't continue to be too much of a problem. 

Broad Kills usually are the culprit, since they don't follow the laws of imported items, they are not capped. So you could be asked "Explosive Device" or "Injected Poison" despite not being able to bring any more items, either hope the map contains those items already, or try again.

In the future, I might try and fix this by checking if the map contains said items, and if it doesn't, and it has already asked two imported items to be used, it will not hand these kills out.