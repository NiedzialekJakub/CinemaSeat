import { Box} from "@mui/material"
import FilmCard from "./FilmCard"

type Props = {
    films: Film[]
    selectFilm: (id: number) => void;
}

export default function FilmList({films, selectFilm}: Props) {
  return (
    <Box sx={{display: 'flex', flexDirection: 'column', gap: 3}}>
        {films.map(film => (
            <FilmCard key={film.id} film={film} selectFilm={selectFilm} />
        ))}
    </Box>
  )
}
