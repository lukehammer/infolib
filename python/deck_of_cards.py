# making a standard deck of playing cards
suits = ("Hearts", "Diamonds", "Spades", "Clubs")
types = range(2, 11)
types.extend(("Jack", "Queen", "King", "Ace"))
cards = []

for s in suits:
    for t in types:
        card = {}
        card["suit"] = s
        card["type"] = t
        cards.append(card)

print len(cards)
print cards