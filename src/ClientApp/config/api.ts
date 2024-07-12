const API_BASE_URL = 'https://localhost:7191/api/Game';
// const API_BASE_URL = "https://localhost:8080/api/game";

export const API_ENDPOINTS = {
  CHOICES: `${API_BASE_URL}/choices`,
  PLAY: `${API_BASE_URL}/play`,
  SCOREBOARD: 'https://localhost:7191/api/Scoreboard/top-players',
  RESET_SCOREBOARD: 'https://localhost:7191/api/Scoreboard/reset',
};
