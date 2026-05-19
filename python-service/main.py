from fastapi import FastAPI
from pydantic import BaseModel

app = FastAPI(title="AnimeFit Pro Python Service")


class PlanRequest(BaseModel):
    goal: str
    level: str
    days_per_week: int
    anime_style: str


@app.get("/")
def root():
    return {
        "service": "AnimeFit Pro Python Service",
        "status": "running"
    }


@app.post("/generate-plan")
def generate_plan(request: PlanRequest):
    return {
        "plan_name": f"{request.anime_style} {request.goal} {request.days_per_week}-Day Plan",
        "goal": request.goal,
        "level": request.level,
        "days_per_week": request.days_per_week,
        "anime_style": request.anime_style,
        "days": [
            {
                "day": "Monday",
                "focus": "Push",
                "exercises": [
                    {
                        "name": "Bench Press",
                        "sets": 4,
                        "reps": "6-8",
                        "rest_seconds": 120
                    },
                    {
                        "name": "Shoulder Press",
                        "sets": 3,
                        "reps": "8-10",
                        "rest_seconds": 90
                    }
                ]
            },
            {
                "day": "Tuesday",
                "focus": "Pull",
                "exercises": [
                    {
                        "name": "Pull Up",
                        "sets": 4,
                        "reps": "6-10",
                        "rest_seconds": 120
                    },
                    {
                        "name": "Barbell Row",
                        "sets": 3,
                        "reps": "8-10",
                        "rest_seconds": 90
                    }
                ]
            }
        ]
    }