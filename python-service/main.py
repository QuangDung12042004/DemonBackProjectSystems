from fastapi import FastAPI, HTTPException
from pydantic import BaseModel, Field
from typing import List

app = FastAPI(title="AnimeFit AI Service")

# ==========================================
# 1. INPUT VALIDATION (Không cho invalid request lọt vào AI)
# ==========================================
class WorkoutRequest(BaseModel):
    goal: str = Field(..., min_length=2, description="Ví dụ: Tăng cơ, giảm mỡ")
    level: str = Field(..., description="Trình độ: Beginner, Intermediate, Advanced")
    days_per_week: int = Field(..., ge=1, le=7, description="Số ngày tập phải từ 1 đến 7")
    anime_style: str = Field(..., min_length=2, description="Ví dụ: Baki, Toji, Goku")

# ==========================================
# 2. STRUCTURED AI OUTPUT (Chuẩn hóa đầu ra)
# ==========================================
class WorkoutDay(BaseModel):
    day: str
    focus: str
    exercises: List[str]

class WorkoutResponse(BaseModel):
    plan_name: str
    days: List[WorkoutDay]

# ==========================================
# 3. ENDPOINT XỬ LÝ
# ==========================================
@app.post("/api/generate", response_model=WorkoutResponse)
async def generate_workout_plan(req: WorkoutRequest):
    # Tự động chặn nếu level nhập sai
    valid_levels = ["Beginner", "Intermediate", "Advanced"]
    if req.level not in valid_levels:
        raise HTTPException(status_code=400, detail="Level chỉ được là Beginner, Intermediate hoặc Advanced")

    print(f"🚀 Bắt đầu gọi AI tạo giáo án {req.anime_style} trong {req.days_per_week} ngày...")

    # TODO: Khúc này sau này em sẽ móc code gọi OpenAI / Gemini / Prompt thật vào đây
    # Hiện tại mình trả về Mock Data chuẩn xác theo đúng cấu trúc để C# và React đọc được
    
    mock_response = {
        "plan_name": f"Giáo án độ body {req.anime_style} - Level {req.level}",
        "days": [
            {
                "day": "Thứ 2",
                "focus": "Ngực - Tay sau (Sức mạnh tàn bạo)",
                "exercises": ["Incline Bench Press 4x8", "Dumbbell Flyes 3x12", "Tricep Pushdown 3x15"]
            },
            {
                "day": "Thứ 4",
                "focus": "Lưng xô - Tay trước (Lưng quỷ Demon Back)",
                "exercises": ["Deadlift 4x5", "Pull-ups 4xMax", "Barbell Curls 3x10"]
            }
        ]
    }
    
    return mock_response