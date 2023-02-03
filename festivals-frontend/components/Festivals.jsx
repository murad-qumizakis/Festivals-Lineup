import { useEffect, useState } from "react"
import "../src/festival.css"

export default function Festivals({festival}) {

    
    const [loading, setLoading] = useState(true)

    // console.log("festival: ", festival.map(fest => fest.date))
    // sort artists into new array
    let sortedArtists = festival.artists.sort()


  return (
    
    <div>
      <div className="festival">

      <span className="fest-info">
            <div className="festival-card" key={festival.id}>
              <label htmlFor="date">Date:</label>
              <p id="date">{festival.date}</p>
              <label htmlFor="name">Name:</label>
              <p id="name">{festival.name}</p>
              <label htmlFor="location">Location:</label>
              <p id="location">{festival.location}</p>
              <label htmlFor="genre">Genre:</label>
              <p id="genre">{festival.genre}</p>
            </div>
      </span>

      

        <div className="artists">

            {/* <h3>Artists</h3> */}
              {festival.artists.length == 0 ? <h3>Add Artists to this festival!</h3> : sortedArtists.map((artist) => (
                <div className="artist-card" key={artist.id}>
                  <h3 id="name">{artist.name}</h3>
                </div>
              ))}
        
        </div>
    </div>
    </div>
  )
}

// loop over the festival artitsts and display them in the card