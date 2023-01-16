# Projet JCDecaux

On demande à l'utilisateur (côté java) de rentrer son adresse de départ ainsi que son adresse d'arrivée, puis on utilise l'API JCDecaux (côté C#) afin de récupérer différentes stations et de proposer un itinéraire à l'utilisateur.

Nous passons par un système de Proxy/Cache afin d'éviter de faire trop de demandes en peu de temps et de se faire bannir par JCDecacux (ce qui est déjà arrivé à certains), et nous vérifions si l'itinéraire est possible à effectuer (selon la distance, s'il faut passer par la mer etc...)
